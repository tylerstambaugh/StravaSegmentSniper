import { useEffect, useState } from "react";
import authService from "../../api-authorization/AuthorizeService";

export const useApi = <TResponse = any>() => {
  const abortControllers: AbortController[] = [];
  const [currentToken, setCurrentToken] = useState();

  useEffect(() => {
    const fetchToken = async () => {
      setCurrentToken(await authService.getAccessToken());
    };
    fetchToken();
  }, []);

  async function fetch(
    requestUrl: string,
    requestOptions: RequestInit,
    abortController?: AbortController
  ): Promise<TResponse | Error> {
    const localAbortController = abortController ?? new AbortController();
    abortControllers.push(localAbortController);
    let attempt = 0;

    try {
      const response = await sendRequest(attempt, requestUrl, {
        ...requestOptions,
        signal: localAbortController.signal,
      });

      if (!response) {
        return new Error("An unexpected error occurred");
      }

      try {
        const returnResponse = await responseFunc(response);
        return returnResponse;
      } catch (error) {
        if (response.status >= 300) {
          return new Error(
            `Status Code: ${response.status}, Status: ${response.statusText}`
          );
        }
      }

      return new Error("An unexpected error occurred");
    } catch (error) {
      if (error instanceof Error) {
        return error;
      } else {
        return new Error("An unexpected error occurred");
      }
    }
  }

  async function responseFunc(response) {
    const contentType = response.headers.get("content-type")!;
    if (contentType.startsWith("application/json;"))
      return await response.json();
    else if (contentType.startsWith("text/plain;"))
      return new Error(await response.text());
  }

  async function sendRequest(
    attempt: number,
    url: string,
    requestOptions: RequestInit,
    tokenToUse?: string
  ): Promise<Response | undefined> {
    setAuthInHeaders(tokenToUse);

    if (attempt < 2) {
      attempt++;
      let response: Response | undefined = await window.fetch(
        url,
        requestOptions
      );

      if (response?.status === 401 || response?.status === 403) {
        const newToken = await authService.getAccessToken();

        response = await sendRequest(attempt, url, requestOptions, newToken);
      }
      return response;
    }

    function setAuthInHeaders(newToken?: string) {
      requestOptions.headers = {
        ...requestOptions.headers,
        Authorization: `Bearer ${newToken ?? currentToken}`,
      };
    }
  }

  useEffect(() => {
    return () => {
      abortControllers.forEach((controller) => {
        controller.abort();
      });
    };
  }, []);

  return { fetch };
};

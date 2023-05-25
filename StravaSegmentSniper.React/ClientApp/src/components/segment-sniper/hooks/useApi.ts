import { useEffect, useState } from "react";
import authService from "../../api-authorization/AuthorizeService";

export const useApi = <TResponse = any>() => {
  const abortControllers: AbortController[] = [];

  async function fetch<TResponse>(
    requestUrl: string,
    requestOptions: RequestInit,
    abortController?: AbortController
  ): Promise<TResponse | Error> {
    const localAbortController = abortController ?? new AbortController();
    abortControllers.push(localAbortController);

    try {
      const response = await sendRequest(requestUrl, {
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
    url: string,
    requestOptions: RequestInit
  ): Promise<Response | undefined> {
    setAuthInHeaders();

    let response: Response | undefined = await window.fetch(
      url,
      requestOptions
    );
    return response;

    function setAuthInHeaders() {
      const token = async () => await authService.getAccessToken();
      requestOptions.headers = {
        ...requestOptions.headers,
        Authorization: `Bearer ${token}`,
      };
    }
  }
  return { fetch };
};

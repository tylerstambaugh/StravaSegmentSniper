import { useEffect, useState } from "react";
import authService from "../../api-authorization/AuthorizeService";

export interface UseApiCallResponse<T> {
  status: number | null;
  statusText: string | null;
  data: T | null;
  isLoading: boolean;
  error: Error | null;
}

const fetchApiData = async <T>(url: string): Promise<UseApiCallResponse<T>> => {
  const response: UseApiCallResponse<T> = {
    status: null,
    statusText: null,
    data: null,
    isLoading: true,
    error: null,
  };

  if (authService.isAuthenticated()) {
    try {
      const token = await authService.getAccessToken();
      const apiResponse = await fetch(url, {
        headers: !token ? {} : { Authorization: `Bearer ${token}` },
      });
      const json = await apiResponse.json();
      response.status = apiResponse.status;
      response.statusText = apiResponse.statusText;
      response.data = json;
    } catch (error) {
      if(error instanceof Error) {
        response.error = error;
      } else {
        response.error = new Error('An unexpected error occurred ')
      }
    }
  }

  response.isLoading = false;
  return response;
};

export const useApiGet = <T>(url: string): UseApiCallResponse<T> => {
  const [response, setResponse] = useState<UseApiCallResponse<T>>({
    status: null,
    statusText: null,
    data: null,
    isLoading: false,
    error: null,
  });

  useEffect(() => {
    setResponse({ ...response, isLoading: true });

    fetchApiData<T>(url)
      .then((result) => setResponse(result))
      .catch((error) => setResponse({ ...response, error }));
  }, [url]);

  return response;
};



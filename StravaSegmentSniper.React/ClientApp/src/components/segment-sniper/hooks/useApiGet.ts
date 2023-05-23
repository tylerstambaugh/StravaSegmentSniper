import { useState } from "react";
import authService from "../../api-authorization/AuthorizeService";

export interface UseApiCallResponse<T> {
  status: number | null;
  statusText: string | null;
  data: T | null;
  isLoading: boolean;
  error?: Error ;
}

export const useApiGet = async <T>(url: string):  Promise<UseApiCallResponse<T>> => {
  const [status, setStatus] = useState<number>(0);
  const [statusText, setStatusText] = useState<string>('');
  const [data, setData] = useState<any>();
  const [error, setError] = useState<Error>();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  
    setIsLoading(true);
    if(authService.isAuthenticated())
    {
    try {
      const token = await authService.getAccessToken();
      const apiResponse = await fetch(url, {
        headers: !token ? {} : { Authorization: `Bearer ${token}` },
      });
      const json = await apiResponse.json();
      setStatus(apiResponse.status);
      setStatusText(apiResponse.statusText);
      setData(json);
    } catch (error) {
      if(error instanceof Error) {
        setError(error);
      }
      else {
        setError(new Error('an unexpected error occurred in useApiGet'))
      }
    }
  }
    setIsLoading(false);
  return { status, statusText, data, error, isLoading };
};
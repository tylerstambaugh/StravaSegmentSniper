import { useEffect, useState } from "react";
import authService from "../../api-authorization/AuthorizeService";
import axios, { AxiosRequestConfig } from "axios";

export const useAxios = <T>(): [
  boolean,
  T | undefined,
  string,
  (
    requestUrl: string,
    requestMethod: string,
    config?: AxiosRequestConfig<any>
  ) => void
] => {
  const abortControllers: AbortController[] = [];
  const token = async () => await authService.getAccessToken();

  const [loading, setLoading] = useState(true);
  const [data, setData] = useState<T>();
  const [error, setError] = useState("");
  const [requestConfig, setRequestConfig] = useState<AxiosRequestConfig>({});

  //   useEffect(() => {
  //     if (loadOnStart) sendRequest();
  //   }, []);

  const request = (
    requestUrl: string,
    requestMethod: string,
    config?: AxiosRequestConfig<any>
    //loadOnStart: boolean = true
  ) => {
    setRequestConfig({
      url: requestUrl,
      method: requestMethod,
      headers: { Authorization: `Bearer ${token}` },
    });
    sendRequest();
  };

  const sendRequest = () => {
    axios(requestConfig)
      .then((response) => {
        setError("");
        setData(response.data);
      })
      .catch((error) => {
        setError(error.message);
      })
      .finally(() => setLoading(false));
  };
  return [loading, data, error, request];
};

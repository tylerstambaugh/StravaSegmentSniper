import { useEffect, useState } from "react";
import authService from "../../api-authorization/AuthorizeService";
import axios, { AxiosRequestConfig } from "axios";

export const useAxios = <T>(
  config: AxiosRequestConfig<any>,
  loadOnStart: boolean = true
): [boolean, T | undefined, string, () => void] => {
  const abortControllers: AbortController[] = [];
  const token = async () => await authService.getAccessToken();

  const [loading, setLoading] = useState(true);
  const [data, setData] = useState<T>();
  const [error, setError] = useState("");

  useEffect(() => {
    if (loadOnStart) sendRequest();
  }, []);

  const request = () => {
    sendRequest();
  };

  const sendRequest = () => {
    axios(config)
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

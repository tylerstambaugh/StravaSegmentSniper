import { useState } from "react";
import { TApiResponse } from "../models/apiResponse";

const useApiGet = (url: string): TApiResponse => {
  const [status, setStatus] = useState<Number>(0);
  const [statusText, setStatusText] = useState<String>('');
  const [data, setData] = useState<any>();
  const [error, setError] = useState<any>();
  const [loading, setLoading] = useState<boolean>(false);

  const getApiData = async () => {
    setLoading(true);
    try {
      const apiResponse = await fetch(url);
      const json = await apiResponse.json();
      setStatus(apiResponse.status);
      setStatusText(apiResponse.statusText);
      setData(json);
    } catch (error) {
      setError(error);
    }
    setLoading(false);
  };
  return { status, statusText, data, error, loading };
};

export default useApiGet;


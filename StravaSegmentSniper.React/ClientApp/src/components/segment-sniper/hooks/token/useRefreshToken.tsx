import { useState } from "react";
import { useApi } from "../useApi";
import { RefreshTokenResponse } from "../../models/token/refreshTokenResponse";

const useRefreshToken = () => {
  const api = useApi<RefreshTokenResponse>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<Error>();

  async function fetch(
    refreshToken: string
  ): Promise<Error | RefreshTokenResponse> {
    setLoading(true);
    try {
      const requestOptions: RequestInit = {
        method: "GET",
      };
      const fetchResponse: RefreshTokenResponse | Error = await api.fetch(
        `url`,
        requestOptions
      );
      if (fetchResponse instanceof Error) {
        setError(fetchResponse);
        throw new Error(error?.message);
      }
      return fetchResponse;
    } catch (error) {
      if (error instanceof Error) {
        setError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setError(newError);
        return newError;
      }
    } finally {
      setLoading(false);
    }
  }
  return { loading, error, fetch };
};

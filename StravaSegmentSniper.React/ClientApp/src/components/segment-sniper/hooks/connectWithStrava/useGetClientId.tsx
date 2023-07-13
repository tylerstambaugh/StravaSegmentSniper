import { useState } from "react";
import { useApi } from "../useApi";

const useGetClientId = () => {
  const api = useApi();
  const [connectLoading, setConnectLoading] = useState(false);
  const [connectError, setConnectError] = useState<Error | undefined>();

  async function fetchClientId() {
    setConnectLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "GET",
      };

      const fetchResponse = await api.fetch(
        "/api/ConnectWithStrava/GetClientId",
        requestOptions
      );

      if (fetchResponse instanceof Error) {
        setConnectError(fetchResponse);
        throw new Error(fetchResponse.message);
      }
      return fetchResponse;
    } catch (error) {
      if (error instanceof Error) {
        setConnectError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setConnectError(newError);
        return newError;
      }
    } finally {
      setConnectLoading(false);
    }
  }

  return { connectLoading, connectError, fetchClientId };
};

export default useGetClientId;

export interface ClientIdResponse {
  ClientId: string;
}

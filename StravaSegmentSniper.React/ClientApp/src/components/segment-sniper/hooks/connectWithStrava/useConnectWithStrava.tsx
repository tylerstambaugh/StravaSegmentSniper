import { useState } from "react";
import { useApi } from "../useApi";
import { ConnectWithStravaResponse } from "../../models/Account/ConnectWithStravaResponse";

const useConnectWithStrava = () => {
  const api = useApi();
  const [connectLoading, setConnectLoading] = useState(false);
  const [connectError, setConnectError] = useState<Error | undefined>();

  async function fetchConnectWithStrava(): Promise<
    ConnectWithStravaResponse | Error
  > {
    setConnectLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "GET",
      };

      const fetchResponse: ConnectWithStravaResponse | Error = await api.fetch(
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

  return { connectLoading, connectError, fetchConnectWithStrava };
};

export default useConnectWithStrava;

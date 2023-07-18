import { useState } from "react";
import { useApi } from "../useApi";
import { WebAppUser } from "../../models/webAppUser";

const useGetWebAppUser = () => {
  const api = useApi();
  const [userLoading, setUserLoading] = useState(false);
  const [userError, setUserError] = useState<Error | undefined>();

  async function fetchUser(): Promise<WebAppUser | Error> {
    setUserLoading(true);

    try {
      const requestOptions: RequestInit = {
        method: "GET",
      };

      const fetchResponse: WebAppUser | Error = await api.fetch(
        "/user",
        requestOptions
      );

      if (fetchResponse instanceof Error) {
        setUserError(fetchResponse);
        throw new Error(fetchResponse.message);
      }

      return fetchResponse;
    } catch (error) {
      if (error instanceof Error) {
        setUserError(error);
        return error;
      } else {
        const newError: Error = new Error("An unexpected error occurred");
        setUserError(newError);
        return newError;
      }
    } finally {
      setUserLoading(false);
    }
  }

  return { userLoading, userError, fetchUser };
};

export default useGetWebAppUser;

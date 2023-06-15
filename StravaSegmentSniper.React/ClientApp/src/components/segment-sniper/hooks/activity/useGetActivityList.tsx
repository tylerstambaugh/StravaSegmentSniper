import { useState } from "react";
import { ActivityListItem } from "../../models/Activity/ActivityListItem";
import { ActivitySearchProps } from "../../scenes/activity/Activity";
import { useApi } from "../useApi";

const useGetActivityList = () => {
  const api = useApi<ActivityListItem[]>();
  const [activityLoading, setActivityLoading] = useState(false);
  const [activityError, setActivityError] = useState<Error>();

  async function fetchActivity(
    activitySearchProps: ActivitySearchProps
  ): Promise<Error | ActivityListItem[] | undefined> {
    setActivityLoading(true);

    if (activitySearchProps.activityId) {
      return fetchByActivityId(activitySearchProps.activityId);
    } else if (activitySearchProps.startDate && activitySearchProps.endDate) {
      return fetchByActivityDateRange(
        activitySearchProps.startDate,
        activitySearchProps.endDate
      );
    } else {
      setActivityLoading(false);
      const error: Error = new Error(
        "Valid Activity ID or Start Date and End Date are required to search."
      );
      setActivityError(error);
      return error;
    }

    async function fetchByActivityId(activityId: number) {
      try {
        const requestOptions: RequestInit = {
          method: "GET",
        };
        const fetchResponse: ActivityListItem[] | Error = await api.fetch(
          `/api/StravaActivity/ActivityListById?activityId=${activitySearchProps.activityId}`,
          requestOptions
        );
        if (fetchResponse instanceof Error) {
          setActivityError(fetchResponse);
          throw new Error(activityError?.message);
        }
        return fetchResponse;
      } catch (error) {
        if (error instanceof Error) {
          setActivityError(error);
          return error;
        } else {
          const newError: Error = new Error("An unexpected error occurred");
          setActivityError(newError);
          return newError;
        }
      } finally {
        setActivityLoading(false);
      }
    }

    async function fetchByActivityDateRange(startDate: Date, endDate: Date) {
      try {
        const bodyData = {
          startDate,
          endDate,
        };
        console.log(`request start date ${startDate}`);
        console.log(`request start date ${endDate}`);

        console.log(`request body data= ${JSON.stringify(bodyData, null, 4)}`);

        const requestOptions: RequestInit = {
          method: "POST",
          body: JSON.stringify(bodyData),
        };
        const fetchResponse: ActivityListItem[] | Error = await api.fetch(
          `/api/StravaActivity/ActivityListByDates`,
          requestOptions
        );
        console.log(
          `useGetActivityList response =  ${JSON.stringify(
            fetchResponse,
            null,
            4
          )}`
        );

        if (fetchResponse instanceof Error) {
          setActivityError(fetchResponse);
          console.log(`useGetActivity error:  ${fetchResponse}`);
          throw new Error(activityError?.message);
        }
        return fetchResponse;
      } catch (error) {
        if (error instanceof Error) {
          setActivityError(error);
          return error;
        } else {
          const newError: Error = new Error("An unexpected error occurred");
          setActivityError(newError);
          return newError;
        }
      } finally {
        setActivityLoading(false);
      }
    }
  }
  return { activityLoading, activityError, fetchActivity };
};

export default useGetActivityList;

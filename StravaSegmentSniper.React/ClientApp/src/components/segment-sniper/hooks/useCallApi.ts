import { useState } from "react";
import authService from "../../api-authorization/AuthorizeService";

const useCallApi = <TResponse = any>() => {
    const abortControllers: AbortController[] = [];

const token = async () => await authService.getAccessToken();

async function fetch(url: string, requestOptions: RequestInit, AbortController?: AbortController,): Promise<TResponse | Error> {
    
    try {
        const response: Response = await window.fetch(url, requestOptions);

        return response;
    }
}

}

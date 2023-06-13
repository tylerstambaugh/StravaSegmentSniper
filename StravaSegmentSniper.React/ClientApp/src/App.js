import React, { Component } from "react";
import { Route, Routes } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import { Layout } from "./components/Layout";
import "./custom.css";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { ToastContainer } from 'react-toastify';


export default class App extends Component {
  static displayName = "Strava Segment Sniper";

  render() {
    return (
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <Layout>
          <Routes>
            {AppRoutes.map((route, index) => {
              const { element, requireAuth, ...rest } = route;
              return (
                <Route
                  key={index}
                  {...rest}
                  element={
                    requireAuth ? (
                      <AuthorizeRoute {...rest} element={element} />
                    ) : (
                      element
                    )
                  }
                />
              );
            })}
          </Routes>
          <ToastContainer />
        </Layout>
      </LocalizationProvider>
    );
  }
}

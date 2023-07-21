import React, { Component } from "react";
import { Route, Routes } from "react-router-dom";
import AppRoutes from "./AppRoutes";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import { Layout } from "./components/Layout";
import "./custom.css";
import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { ToastContainer } from 'react-toastify';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faStar as solidStar, faCircleCheck as circleCheck } from "@fortawesome/free-solid-svg-icons";
import { faStar as regularStar } from "@fortawesome/free-regular-svg-icons"

library.add( solidStar, regularStar, circleCheck)

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
          <ToastContainer position="top-right"
autoClose={5000}
hideProgressBar={false}
newestOnTop={false}
closeOnClick
rtl={false}
pauseOnFocusLoss
draggable
pauseOnHover
theme="light"/>
        </Layout>
      </LocalizationProvider>
    );
  }
}

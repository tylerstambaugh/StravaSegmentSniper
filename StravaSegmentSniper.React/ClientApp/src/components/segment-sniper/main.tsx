import React, { useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import { WebAppUser } from "./models/webAppUser";
import { ApplicationPaths } from "../api-authorization/ApiAuthorizationConstants";
import { Container, Row } from "react-bootstrap";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const loginPath = `${ApplicationPaths.Login}`;
  //const [stravaId, setStravaId] = useState([]);
  const [appUser, setAppUser] = useState<WebAppUser>();

  useEffect(() => {
    const _subscription = authService.subscribe(() => populateState());
    populateState();

    return () => {
      authService.unsubscribe(_subscription);
    };
  });

  async function populateState() {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser(),
    ]);
    setIsAuthenticated(isAuthenticated);
    setUsername(user && user.name);
    console.log(`user from populate state = ${JSON.stringify(user, null, 4)}`);
    //setStravaId(user);
  }

  async function callAPI(e: React.MouseEvent<HTMLButtonElement, MouseEvent>) {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await fetch("/user", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` },
    });
    const data = await response.json();
    setAppUser(data);
  }

  if (isAuthenticated) {
    return (
      <Container>
        <Row>
          <div className="col-6">{userName} is authenticated</div>
          <div className="main-tile">
            <Row>
              <ul>
                <li style={{ cursor: "pointer" }}>
                  <Link to="./athlete">View Athlete Details</Link>
                </li>
                <li style={{ cursor: "pointer" }}>
                  <Link to="./activity">Activities and Segment</Link>
                </li>
                <li style={{ cursor: "pointer" }}>Token Maintenance</li>
              </ul>
            </Row>
          </div>
          <Row>
            <label style={{ display: "inline-flex" }}>
              testing button:
              <button onClick={(e) => callAPI(e)}>Call API</button>
              <h3>webappuser: {appUser?.id}</h3>
            </label>
          </Row>
          <Row>
            <button>
              <img src={"./assets/btn_strava_connectwith_orange.png"} />
            </button>
          </Row>
        </Row>
      </Container>
    );
  } else {
    return (
      <main className="container">
        <div className="row justify-content-center mt-3 mb-3">
          <div className="col-6">
            <p>You must be logged in to access this app.</p>
            <p>
              Click
              <Link to={loginPath}> here </Link>
              to login.
            </p>
          </div>
        </div>
      </main>
    );
  }
}

export default SegmentSniper;

// const [error, setError] = useState(null);
// const [isLoaded, setIsLoaded] = useState(false);
// const [items, setItems] = useState([]);

// Note: the empty deps array [] means
// this useEffect will run once
// similar to componentDidMount()
// useEffect(() => {
//   fetch("user")
//     .then((res) => res.json())
//     .then(
//       (result) => {
//         setIsLoaded(true);
//         setItems(result);
//         console.log(`use effect result ${result}`);
//       },
//       // Note: it's important to handle errors here
//       // instead of a catch() block so that we don't swallow
//       // exceptions from actual bugs in components.
//       (error) => {
//         setIsLoaded(true);
//         setError(error);
//       }
//     );
// }, []);
// function MyComponent() {
//     const [error, setError] = useState(null);
//     const [isLoaded, setIsLoaded] = useState(false);
//     const [items, setItems] = useState([]);

//     // Note: the empty deps array [] means
//     // this useEffect will run once
//     // similar to componentDidMount()
//     useEffect(() => {
//         fetch("https://api.example.com/items")
//             .then(res => res.json())
//             .then(
//                 (result) => {
//                     setIsLoaded(true);
//                     setItems(result);
//                 },
//                 // Note: it's important to handle errors here
//                 // instead of a catch() block so that we don't swallow
//                 // exceptions from actual bugs in components.
//                 (error) => {
//                     setIsLoaded(true);
//                     setError(error);
//                 }
//             )
//     }, [])

//     if (error) {
//         return <div>Error: {error.message}</div>;
//     } else if (!isLoaded) {
//         return <div>Loading...</div>;
//     } else {
//         return (
//             <ul>
//                 {items.map(item => (
//                     <li key={item.id}>
//                         {item.name} {item.price}
//                     </li>
//                 ))}
//             </ul>
//         );
//     }
// }

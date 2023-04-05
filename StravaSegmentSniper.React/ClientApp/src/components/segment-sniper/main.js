import React, { Component, useEffect, useState } from "react";
import { Link, Routes, Route } from "react-router-dom";
import authService from "../api-authorization/AuthorizeService";
import Activity from "./activity/Activity";

function SegmentSniper() {
  const [userName, setUsername] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [stravaId, setStravaId] = useState([]);
  const [webAppUser, setWebAppUser] = useState([]);

  useEffect(() => {
    const _subscription = authService.subscribe(() => this.populateState());
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
    console.log(`user from populate state = ${console.log(JSON.stringify(user, null, 4))}`);
   // setStravaId(user);
  }

  function handleTileClick(event) {}
  
  
  const [error, setError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);

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


  async function callAPI() {
    const token = await authService.getAccessToken();
    console.log(token);
    const response = await fetch('user', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    setWebAppUser(data);
  }

  if (isAuthenticated) {
    return (
      <main className="container">
        <div className="row justify-content-center mt-3 mb-3">
          <div className="col-6">{userName} is authenticated</div>
          <div className="main-tile">
            <ul>
              <li style={{ cursor: "pointer" }}>
                <Link to="./athlete">View Athlete Details</Link>
              </li>
              <li style={{ cursor: "pointer" }}>
                <Link to="./activity">Activities and Segment</Link>
              </li>
              <li onClick={handleTileClick} style={{ cursor: "pointer" }}>
                Token Maintenance
              </li>
            </ul>
          </div>
          <div>
            <p>testing button:</p>
            <button onClick={callAPI}>Call API</button>
                <h3>webappuser: {webAppUser}</h3>
                <h3>stravaAthleteId: {stravaId}</h3>
          </div>
        </div>
      </main>
    );
  } else {
    return (
      <main className="container">
        <div className="row justify-content-center mt-3 mb-3">
          <div className="col-6">Loading...</div>
        </div>
      </main>
    );
  }
}

export default SegmentSniper;

//       <nav className='nav'>
//         <Link to="/" className="nav-item">Homepage</Link>
//         <Link to="/about-me" className='nav-item'>About Me</Link>
//         <Link to="/contact" className='nav-item'>Contact</Link>
//       </nav>
//       <Routes>
//       <Route path="/" element={<Homepage />} />
//       <Route path="/about-me" element={<AboutMe />} />
//       <Route path="/contact" element={<Contact />} />
//       </Routes>

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

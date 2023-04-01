import React, { Component, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import authService from '../api-authorization/AuthorizeService';


function SegmentSniper() {

    const [userName, setUsername] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() =>{
        const _subscription = authService.subscribe(() => populateState());
        populateState();

        return () => {
            authService.unsubscribe(_subscription);
          };
    },[userName]);

    async function populateState() {
    const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
    setIsAuthenticated(isAuthenticated);
      setUsername(user && user.name)
    }
  

  if(isAuthenticated) {
  return (
    <div>{ userName} is authenticated</div>
  );
  } else {
    return (
        <div>loading... </div>
    );
  }
}

export default SegmentSniper;



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
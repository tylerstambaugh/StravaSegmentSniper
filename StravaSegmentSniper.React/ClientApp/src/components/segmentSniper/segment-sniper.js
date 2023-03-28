import React, { Component, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import authService from '../api-authorization/AuthorizeService';

const SegmentSniper = () => { 

    const user = authService.getUser();
         // const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        //this.setState({
        //    isAuthenticated,
        //    userName: user && user.name
    //    });
    

    return (
        (user != null) ?            
            <main>
                <p>this is the segment sniper homepage: { user }</p>
            </main>

            : <main>Loading...</main>
    )
}

export default SegmentSniper;


//<main>
//    <RankingGrid items={items} imgArr={imgArr} drag={drag} allowDrop={allowDrop} drop={drop} />
//    <ItemCollection items={items} drag={drag} imgArr={imgArr} />
//    <button onClick={Reload} style={{ "marginTop": "10px" }}>Reset</button>
//</main>
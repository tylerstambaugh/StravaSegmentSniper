import React, { useEffect, useState } from 'react';


function basicAthlete() {


    function getDataFromApi() {
        fetch(`athlete/${athleteId}`)
            .then((results) => {
                return results.json();
            })
            .then(data => {
                setItems(data);
            })
    }


    return (

    );
}
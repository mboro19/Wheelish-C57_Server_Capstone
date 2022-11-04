import React from "react";
import { useNavigate, useParams } from "react-router-dom";
import {Card, CardBody, Button } from "reactstrap";
import { useState, useEffect } from "react";
import { GetVehicleDealer } from "../modules/authManager";
import { VehicleDealerDetails } from "./VehicleDealerDetails";

export const Dealer = () => {
    const { userId } = useParams();
    const [dealer, setDealer] = useState({});


useEffect(()=>{
    GetVehicleDealer(userId).then((userV) => {
        setDealer(userV)
    })
    
    },[])
    return VehicleDealerDetails(dealer)
}
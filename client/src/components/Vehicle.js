import React from "react";
import { Card, CardBody} from "reactstrap";
import {Link} from 'react-router-dom';
import { VehicleDealerDetails } from "./VehicleDealerDetails";
import { GetVehicleDealer } from "../modules/authManager";
import { Dealer } from "./Dealer";

export const Vehicles = ({ vehicle }) => {
  return (
    <Card >
      <CardBody>
        <p><b>Make:</b> {vehicle.vehicleMake}</p>
        <p><b>Model:</b> {vehicle.vehicleModel}</p>
        <p><b>Miles:</b> {vehicle.userVehicles.vehicleMiles}</p>
        <p><b>Cost:</b> ${vehicle.userVehicles.vehicleCost}</p>
        <p><b>Year:</b> {vehicle.vehicleYear}</p>
        
        <Link to = {`/Dealer/${vehicle.userVehicles.userId}`} >Contact Dealer!</Link>

      </CardBody>
    </Card>
  );
};


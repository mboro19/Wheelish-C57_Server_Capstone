import React from "react";
import { Card, CardBody, Button} from "reactstrap";
import { VehicleEdit } from "./VehicleEdit";
import {Link} from 'react-router-dom';
import { deleteVehicle } from "../modules/vehicleManager";

export const Vehicles = ({ vehicle }) => {

  return (
    <Card >
      <CardBody>
        <p><b>Make:</b> {vehicle.vehicleMake}</p>
        <p><b>Model:</b> {vehicle.vehicleModel}</p>
        <p><b>Miles:</b> {vehicle.userVehicles.vehicleMiles}</p>
        <p><b>Cost:</b> ${vehicle.userVehicles.vehicleCost}</p>
        <p><b>Year:</b> {vehicle.vehicleYear}</p>
        <Link to= {`/VehicleEdit/${vehicle.id}`}>Edit Vehicle</Link>
        <Link onClick={()=>{deleteVehicle(vehicle.id)}} >Delete Vehicle</Link>


      </CardBody>
    </Card>
  );
};


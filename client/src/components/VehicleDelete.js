import React from "react";
import { useNavigate } from "react-router-dom";
import {Card, CardBody, Button } from "reactstrap";
import { deleteVehicle } from "../modules/vehicleManager";

const deleteThisVehicle = (id, nav) => {
    deleteVehicle(id).then(() => nav("/MyVehiclesList"))
}


export default function DeleteMyVehicle({ vehicle } ) {
    const navigate = useNavigate();
    return (
        <Card className="m-4">
            <CardBody>
                {vehicle.VehicleYear}
                {vehicle.VehicleMake}
                {vehicle.VehicleModel}
                <br />
                <Button color="danger" size="sm" onClick={()=>deleteThisVehicle(vehicle.id, navigate)}>Delete?</Button>
                <Button color="light" size="sm" onClick={()=>navigate("/")}>Cancel</Button>
            </CardBody>
        </Card>
    );
}
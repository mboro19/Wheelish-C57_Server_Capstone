import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Login from "./Login.js";
import Register from "./Register.js";
import Hello from "./Hello.js";
import VehicleList from "./MyVehiclesList.js";
import AllVehicles from "./AllVehicles.js";
import VehicleAdd from "./VehicleAdd.js";
import { VehicleEdit } from "./VehicleEdit.js";


export function ApplicationViews({ isLoggedIn }) {

  return (
    <main>
      <Routes>
        <Route path="/">
          <Route
            index
            element={isLoggedIn ? <Hello /> : <Navigate to="/login" />}
          />
          <Route path="login" element={<Login />} />
          <Route path="register" element={<Register />} />
          <Route path="MyVehiclesList" element={<VehicleList />} />
          <Route path="VehicleAdd" element={<VehicleAdd />} />
          <Route path="VehicleEdit/:vehicleId" element={<VehicleEdit />} />
          <Route path="AllVehicles" element={<AllVehicles />} />
          <Route path="*" element={<p>Whoops, nothing here...</p>} />
        </Route>
      </Routes>
    </main>
  );
};


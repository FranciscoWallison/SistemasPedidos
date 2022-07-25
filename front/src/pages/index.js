import React from 'react';
import {
    Routes, Route
} from "react-router-dom";
import Layout from "./Layout";
import Home from './Home';
import User from './user';

const rootElement = document.getElementById("root");

const Webpages = () => {
    return(
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route index element={<Home />} />
                <Route path="User" element={<User />} />
            </Route>
        </Routes>
    );
};
export default Webpages;
import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";

/*
Startar React-applikationen och renderar App-komponenten
i HTML-elementet med id="root".
*/

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);

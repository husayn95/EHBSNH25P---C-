import React from "react";
import CourseList from "./CourseList";

/*
App är huvudkomponenten för frontend.
Den visar sidans titel och laddar CourseList.
*/

function App() {
    return (
        <div>

            <h1>Course Manager</h1>

            <CourseList />

        </div>
    );
}

export default App;
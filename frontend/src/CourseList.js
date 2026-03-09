import React, { useEffect, useState } from "react";

/*
CourseList hanterar alla kurser i systemet.
*/

function CourseList() {

    const [courses, setCourses] = useState([]);
    const [title, setTitle] = useState("");
    const [teacher, setTeacher] = useState("");
    const [editingId, setEditingId] = useState(null);



    /*
    Hämtar alla kurser
    */

    const loadCourses = () => {

        fetch("https://localhost:7112/courses")
            .then(res => res.json())
            .then(data => setCourses(data));

    };

    useEffect(() => {
        loadCourses();
    }, []);



    /*
    Skapa kurs
    */

    const addCourse = async () => {

        const course = {
            title: title,
            teacherName: teacher
        };

        await fetch("https://localhost:7112/courses", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(course)
        });

        setTitle("");
        setTeacher("");

        loadCourses();
    };



    /*
    Ta bort kurs
    */

    const deleteCourse = async (id) => {

        await fetch(`https://localhost:7112/courses/${id}`, {
            method: "DELETE"
        });

        loadCourses();
    };



    /*
    Starta redigering
    */

    const startEdit = (course) => {

        setEditingId(course.id);
        setTitle(course.title);

        if (course.courseInstances?.length > 0) {
            setTeacher(course.courseInstances[0].teacher?.name || "");
        }

    };



    /*
    Uppdatera kurs
    */

    const updateCourse = async () => {

        const updatedCourse = {
            id: editingId,
            title: title,
            teacherName: teacher
        };

        await fetch(`https://localhost:7112/courses/${editingId}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(updatedCourse)
        });

        setEditingId(null);
        setTitle("");
        setTeacher("");

        loadCourses();
    };



    return (

        <div style={{ padding: "20px", fontFamily: "Arial" }}>

            <h2>Create / Edit Course</h2>

            <input
                placeholder="Course name"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
            />

            <input
                placeholder="Teacher name"
                value={teacher}
                onChange={(e) => setTeacher(e.target.value)}
                style={{ marginLeft: "10px" }}
            />

            {editingId ? (

                <button
                    onClick={updateCourse}
                    style={{ marginLeft: "10px" }}
                >
                    Update Course
                </button>

            ) : (

                <button
                    onClick={addCourse}
                    style={{ marginLeft: "10px" }}
                >
                    Add Course
                </button>

            )}



            <h2 style={{ marginTop: "30px" }}>Course List</h2>

            <ul style={{ listStyle: "none", padding: 0 }}>

                {courses.map(course => (

                    <li
                        key={course.id}
                        style={{
                            marginBottom: "10px",
                            padding: "10px",
                            border: "1px solid #ccc",
                            borderRadius: "5px"
                        }}
                    >

                        <strong>{course.title}</strong>

                        {" - "}

                        {
                            course.courseInstances && course.courseInstances.length > 0
                                ? course.courseInstances[0].teacher?.name
                                : "No teacher assigned"
                        }

                        <button
                            onClick={() => startEdit(course)}
                            style={{ marginLeft: "15px" }}
                        >
                            Edit
                        </button>

                        <button
                            onClick={() => deleteCourse(course.id)}
                            style={{ marginLeft: "10px", color: "red" }}
                        >
                            Delete
                        </button>

                    </li>

                ))}

            </ul>

        </div>

    );
}

export default CourseList;
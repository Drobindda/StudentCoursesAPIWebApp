const uri = 'api/Courses';
let courses = [];

function getCourses() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCourses(data))
        .catch(error => console.error('Unable to get courses.', error));
}

function addCourse() {
    const addNameTextbox = document.getElementById('add-name');
    const addDescriptionTextbox = document.getElementById('add-description');

    const course = {
        name: addNameTextbox.value.trim(),
        description: addDescriptionTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(course)
    })
        .then(response => response.json())
        .then(() => {
            getCourses();
            addNameTextbox.value = '';
            addDescriptionTextbox.value = '';
        })
        .catch(error => console.error('Unable to add course.', error));
}

function deleteCourse(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCourses())
        .catch(error => console.error('Unable to delete course.', error));
}

function displayEditForm(id) {
    const course = courses.find(course => course.id === id);

    document.getElementById('edit-id').value = course.id;
    document.getElementById('edit-name').value = course.name;
    document.getElementById('edit-description').value = course.description;
    document.getElementById('editForm').style.display = 'block';
}

function updateCourse() {
    const courseId = document.getElementById('edit-id').value;
    const course = {
        id: parseInt(courseId, 10),
        name: document.getElementById('edit-name').value.trim(),
        description: document.getElementById('edit-description').value.trim()
    };

    fetch(`${uri}/${courseId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(course)
    })
        .then(() => getCourses())
        .catch(error => console.error('Unable to update course.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayCourses(data) {
    const tBody = document.getElementById('courses');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(course => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${course.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCourse(${course.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(course.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeDescription = document.createTextNode(course.description);
        td2.appendChild(textNodeDescription);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    courses = data;
}

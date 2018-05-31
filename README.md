# MediSched

### What is MediSched?

MediSched is a user interface prototype for a desktop productivity tool aimed at helping medical specialists, such as doctors and chiropractors, who operate small scale practices to seamlessly schedule patients, maintain their patients’ medical histories, and manage their employees. 
The application emphasizes unifying otherwise scattered patient information into a simple and easy to process format, where all aspects of a patient’s clinic experience are intuitively connected in a way that makes it easy to explore, create, and edit. (wow so many buzzwords!)

MediSched was written in C# using the WPF framework.

### Project Video

[![MediSched Demo](https://i.imgur.com/Fn2MxWF.png)](https://youtu.be/0gZuJtG4wn8)

### Features

**View patient information:**

The ability to view stored patient information.

Patient information can be accessed from clicking on a name in the patient search (Figure 8), or by clicking the patient name on an appropriate appointment window (Figure 2.1.a).


**Add a new patient:**

The ability to new add new patients with their information to the system.

New patients can be added through the new patient window (Figure 5), which can be accessed either through “New Patient” button on the patient search window (Figure 8) or through the new appointment process by clicking the “New Patient” button on the new appointment window (Figure 4.c).

**Show patient’s appointment history/future:**

The ability to see all of a patient’s past or upcoming appointments.

This information can accessed from the patient information window (Figure 9) by clicking on either the history/future tabs (Figure 9.1.a).


**Edit patient information:**

The ability to edit an existing patient’s information.

This can be done from the patient information window (Figure 9), by clicking the edit icon in the tab you want to edit (Figure 9.1.b) and filling out the text boxes.


**View appointment information:**

The ability to view information for a specific appointment.

This can be done through a variety of methods. An appointment block can be clicked on any page in which it appears, including the main window (Figure 1.2.a), the new appointment day view (Figure 7.2.a) , and the calendar day view (Figure 11.2.a). An appointment can also be clicked in the list of past or future appointments for a patient (Figure 9.3.a).


**View/change appointment status:**

The ability to view or change the status of an appointment.

The status can be seen on any window in which appointment blocks appear, including the main window (Figure 1.2.a), the new appointment day view (Figure 7.2.a) , and the calendar day view (Figure 11.2.a). The appointment status is indicated by its colour, with a legend on each applicable page (Figure 1.1.f).
An appointment’s status can be changed from any appropriate appointment window by clicking one of the appointment status radio buttons (Figure 2.1.d)


**View/write appointment session notes:**

The ability to write arbitrary notes about a specific appointment, or view already written notes.

This can be done on any appropriate appointment window, by clicking the “View Notes” Button (Figure 2.1.c). To edit the notes, type your changes in the notes box (Figure 2.2.b), and click the “Save Notes” button to save them (Figure 2.2.a).


**Add a new appointment:**

The ability to add a new appointment to the system.

This can be done through the appointment creation process. This process is done by first clicking the “New Appointment” button on the main window (Figure 1.1.a), selecting a patient to create the appointment for on the new appointment window (Figure 4.b), selecting an appointment type (Figure 6.a), a duration (Figure 6.b), and finally clicking a day from the new appointment month view (Figure 6.d), and finally selecting a time block on the new appointment day view (Figure 7.2.a).


**Delete an existing appointment:**

The ability to delete an appointment currently in the system.

This can be done from the appropriate appointment window by clicking the “Delete” button (Figure 2.1.e).


**View all existing appointments:**

The ability to view all appointments at any period of time.

Existing appointments can be viewed through the calendar process. This is accomplished by first clicking the “Calendar” button on the main window (Figure 1.1.c), then choosing the day you want to see appointments for (Figure 10.b), and finally clicking the specific appointment of interest on the calendar day view (Figure 11.2.a).


**View/change appointment billing information:**

The ability to view or change the billing information of a billing appointment.

This can be accomplished by entering details in the add item textbox and the add cost textbox and hitting the + button (Figure 3.b). This information will be displayed in the data grid as a new row. Hitting Delete (inside Figure 3.a)  will remove the row, and hitting edit (inside Figure 3.1) will open a new window that allows the user to edit the description and cost of that row. When the user is satisfied with the data in the grid, they can hit the Print button (figure 3.c) to send the data to the printer and/or Save (Figure 3.d) which will save the data and close the billing window.


**Edit/delete/add doctors:**

The ability to edit, delete and add new doctors to the system.

This can be done by clicking on the ‘Doctor’ button from the main window (Figure 1.2). Once clicked, you are presented with the doctor management window (Figure 12) where you can either delete a doctor by clicking on the `Delete` button (Figure 12.c), edit that doctor’s information by clicking on the `Edit` button (Figure 12.c), or add a new doctor by clicking on the `+` button (Figure 12.d).
When the `Edit` button is clicked, the new doctor window pops up (Figure 13.2) and all the fields are populated using that doctor’s information. The user has the ability to edit any of the information shown on this window. Once the user is done editing and they click the `Ok` button, the new information is reflected on the main screen and on doctor management window.
When `+` button is clicked, the new doctor window pops up (Figure 13.1). The important information required of the doctor is their name and hours, their days are optional. Once the required information is filled and the user clicks the `Ok` button, a new doctor row is shown in the doctor management window (Figure 12) and a new schedule is shown on the main screen (Figure 1.1).

### Screenshots

[insert all those annotated screenshots here]

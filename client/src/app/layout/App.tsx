import { useEffect, useState } from "react";
import axios from "axios";
import { Box, Container, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";

function App() {
	const [activities, setActivities] = useState<Activity[]>([]);
	const [selectedActivity, setSelectedActivity] = useState<
		Activity | undefined
	>(undefined);
	const [editMode, setDitMode] = useState(false);

	useEffect(() => {
		axios
			.get<Activity[]>("https://localhost:5001/api/activities")
			.then((response) => setActivities(response.data));

		// clean up code
		return () => {};
	}, []);

	const handleSelectActivity = (id: string) => {
		setSelectedActivity(activities.find((a) => a.id === id));
	};

	const handleCancelSelectActivity = () => {
		setSelectedActivity(undefined);
	};

	const handleOpenForm = (id?: string) => {
		if (id) handleSelectActivity(id);
		else handleCancelSelectActivity();
		setDitMode(true);
	};

	const handleCloseForm = () => {
		setDitMode(false);
	};

	const handleSubmitForm = (activity: Activity) => {
		if (activity.id) {
			setActivities(
				activities.map((a) => (a.id === activity.id ? activity : a))
			);
		} else {
			const newActivity = {
				...activity,
				id: activities.length.toString(),
			};
			setSelectedActivity(newActivity);
			setActivities([...activities, newActivity]);
		}
		setDitMode(false);
	};

	const handleDelete = (id: string) => {
		setActivities(activities.filter((a) => a.id !== id));
	};

	return (
		<Box sx={{ bgcolor: "#eeeeee" }}>
			{/* removes space between window edges and navbar */}
			<CssBaseline />
			<NavBar openForm={handleOpenForm} />
			<Container
				maxWidth="xl"
				sx={{ mt: 3 }}>
				<ActivityDashboard
					activities={activities}
					selectActivity={handleSelectActivity}
					cancelSelectActivity={handleCancelSelectActivity}
					selectedActivity={selectedActivity}
					editMode={editMode}
					openForm={handleOpenForm}
					closeForm={handleCloseForm}
					submitForm={handleSubmitForm}
					deleteActivity={handleDelete}
				/>
			</Container>
		</Box>
	);
}

export default App;

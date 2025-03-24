import { Box, Typography } from "@mui/material";
import ActivityCard from "./ActivityCard";
import { useActivities } from "../../../lib/hooks/useActivities";

export default function ActivityList() {
	const { activities, isPending } = useActivities();

	if (!activities || isPending) return <Typography>Loading...</Typography>;

	return (
		<Box sx={{ display: "flex", gap: 3, flexDirection: "column" }}>
			{activities.map((activity) => (
				<ActivityCard
					key={activity.id}
					activity={activity}
				/>
			))}
		</Box>
	);
}

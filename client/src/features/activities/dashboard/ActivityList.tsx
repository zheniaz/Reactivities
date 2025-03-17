import { Box } from "@mui/material";
import ActivityCard from "./ActivityCard";

type Props = {
	activities: Activity[];
	selectActivity: (id: string) => void;
	deleteActivity: (id: string) => void;
};

export default function ActivityList({
	activities,
	selectActivity,
	deleteActivity,
}: Props) {
	return (
		<Box sx={{ display: "flex", gap: 3, flexDirection: "column" }}>
			{activities.map((activity) => (
				<ActivityCard
					key={activity.id}
					activity={activity}
					selectActivity={selectActivity}
					deleteActivity={deleteActivity}
				/>
			))}
		</Box>
	);
}

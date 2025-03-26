import ActivityFilters from "../ActivityFilters";
import ActivityList from "./ActivityList";
import { Grid2 } from "@mui/material";

export default function ActivityDashboard() {
	return (
		<Grid2
			container
			spacing={3}>
			<Grid2 size={7}>
				<ActivityList />
			</Grid2>
			<Grid2 size={4}>
				<ActivityFilters />
			</Grid2>
		</Grid2>
	);
}

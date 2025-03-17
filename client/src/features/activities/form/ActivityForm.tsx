import { Box, Button, TextField } from "@mui/material";
import { Paper, Typography } from "@mui/material";
import { FormEvent } from "react";

type Props = {
	activity?: Activity;
	closeForm: () => void;
	submitForm: (activity: Activity) => void;
};

export default function ActivityForm({
	activity,
	closeForm,
	submitForm,
}: Props) {
	const handleSubit = (event: FormEvent<HTMLFormElement>) => {
		event.preventDefault();

		const formData = new FormData(event.currentTarget);
		const data: { [key: string]: FormDataEntryValue } = {};
		formData.forEach((value, key) => {
			data[key] = value;
		});

		if (activity) data.id = activity.id;

		submitForm(data as unknown as Activity);
	};

	return (
		<Paper sx={{ borderRadius: 3, padding: 3 }}>
			<Typography variant="h5">Create Activity</Typography>
			<Box
				component="form"
				onSubmit={handleSubit}
				display="flex"
				flexDirection="column"
				gap={3}>
				<TextField
					name="title"
					label="Title"
					defaultValue={activity?.title}
				/>
				<TextField
					name="description"
					label="Description"
					multiline
					rows={3}
					defaultValue={activity?.description}
				/>
				<TextField
					name="category"
					label="Category"
					defaultValue={activity?.category}
				/>
				<TextField
					name="date"
					type="date"
					defaultValue={activity?.date}
				/>
				<TextField
					name="city"
					label="City"
					defaultValue={activity?.city}
				/>
				<TextField
					name="venue"
					label="Venue"
					defaultValue={activity?.venue}
				/>
				<Box
					display="flex"
					justifyContent="end"
					gap={3}>
					<Button
						onClick={closeForm}
						color="inherit">
						Cancel
					</Button>
					<Button
						type="submit"
						color="inherit"
						variant="contained">
						Submit
					</Button>
				</Box>
			</Box>
		</Paper>
	);
}

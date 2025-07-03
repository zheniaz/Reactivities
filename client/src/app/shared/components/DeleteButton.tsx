import { Delete, DeleteOutline } from "@mui/icons-material";
import { Box, Button } from "@mui/material";

export default function DeleteButton() {
	return (
		<Box sx={{ position: "relative" }}>
			<Button
				sx={{
					position: "relative",
					transition: "opacity 0.3s",
					opacity: 0.8,
					cursor: "pointer",
				}}>
				<DeleteOutline
					sx={{ fontSize: 32, color: "white", position: "absolute" }}
				/>
				<Delete
					sx={{
						fontSize: 28,
						color: "red",
					}}
				/>
			</Button>
		</Box>
	);
}

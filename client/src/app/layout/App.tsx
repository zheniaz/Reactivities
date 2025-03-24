import { Box, Container, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import { Outlet } from "react-router";

function App() {
	return (
		<Box sx={{ bgcolor: "#eeeeee", minHeight: "100vh" }}>
			{/* removes space between window edges and navbar */}
			<CssBaseline />
			<NavBar />
			<Container
				maxWidth="xl"
				sx={{ mt: 3 }}>
				<Outlet />
			</Container>
		</Box>
	);
}

export default App;

import { Box, Container, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import { Outlet, useLocation } from "react-router";
import HomePage from "../../features/activities/home/HomePage";

function App() {
	const location = useLocation();
	return (
		<Box sx={{ bgcolor: "#eeeeee", minHeight: "100vh" }}>
			{/* removes space between window edges and navbar */}
			<CssBaseline />
			{location.pathname === "/" ? (
				<HomePage />
			) : (
				<>
					<NavBar />
					<Container
						maxWidth="xl"
						sx={{ mt: 3 }}>
						<Outlet />
					</Container>
				</>
			)}
		</Box>
	);
}

export default App;

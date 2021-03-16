import React from "react";
import { Navbar } from "react-bootstrap";

class Navigation extends React.Component {
	render() {
		return (
			<>
				<Navbar bg="dark" variant="dark">
					<Navbar.Brand href="/r6">
						<img
							alt=""
							src="/images/r6-logo.png"
							width="100"
							height="44"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand href="/csgo">
						<img
							alt=""
							src="/images/csgo-logo.png"
							width="100"
							height="44"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand href="/lol">
						<img
							alt=""
							src="/images/lol-logo.png"
							width="100"
							height="35"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
				</Navbar>
			</>
		);
	}
}
export default Navigation;

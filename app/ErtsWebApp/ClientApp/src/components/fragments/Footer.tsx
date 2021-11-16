import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import { createAbsoluteUrl } from "../../Helpers/UrlHelper";
import Resources from "../../Resources";

class Footer extends React.Component<RouteComponentProps> {
	private redirectToPage(page: string) {
		this.props.history.push(page);
	}
	render() {
		return (
			<>
				<Navbar bg="dark" variant="dark" fixed="bottom">
					<Navbar.Brand
						onClick={() =>
							this.redirectToPage("/csgo/leagues")
						}>
						<img
							alt=""
							src="/images/csgo-logo.png"
							width="100"
							height="44"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand
						onClick={() =>
							this.redirectToPage("/lol/leagues")
						}>
						<img
							alt=""
							src="/images/lol-logo.png"
							width="100"
							height="35"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand
						onClick={() =>
							this.redirectToPage("/dota2/leagues")
						}
					>
						<img
							alt=""
							src="/images/dota2-logo.png"
							width="100"
							height="50"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand
						onClick={() =>
							this.redirectToPage("/overwatch/leagues")
						}
					>
						<img
							alt=""
							src="/images/overwatch-logo.png"
							width="100"
							height="30"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<Navbar.Brand
						onClick={() =>
							this.redirectToPage("/valorant/leagues")
						}
					>
						<img
							alt=""
							src="/images/valorant-logo.png"
							width="100"
							height="50"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
					<div className="ml-auto">miejsce na sociale</div>
				</Navbar>
			</>
		);
	}
}
export default withRouter(Footer);

import React from "react";
import { Navbar, Image } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";

class Footer extends React.Component<RouteComponentProps> {
	private redirectToPage(page: string) {
		this.props.history.push(page);
	}

	render() {
		return (
			<>
				<Navbar bg="dark" variant="dark" fixed="bottom">
					<Navbar.Brand style={{ marginLeft: 10 }}
						onClick={() =>
							this.redirectToPage("/csgo/leagues")
						}>
						<Image
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
						<Image
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
						<Image
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
						<Image
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
						<Image
							alt=""
							src="/images/valorant-logo.png"
							width="100"
							height="50"
							className="d-inline-block align-top"
						/>{" "}
					</Navbar.Brand>
				</Navbar>
			</>
		);
	}
}
export default withRouter(Footer);

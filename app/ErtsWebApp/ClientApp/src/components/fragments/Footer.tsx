import React from "react";
import { Navbar } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";

interface IProps {
	//onGameChanged: (gameType: string) => void;
}

class Footer extends React.Component<IProps & RouteComponentProps> {
	private redirectToPage(gameType: string, page: string) {
		this.props.history.push(page);
		//this.props.onGameChanged(gameType)
	}
	render() {
		return (
			<>
				<Navbar bg="dark" variant="dark" fixed="bottom">
					<Navbar.Brand style={{ marginLeft: 10 }}
						onClick={() =>
							this.redirectToPage("csgo", "/csgo/leagues")
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
							this.redirectToPage("lol", "/lol/leagues")
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
							this.redirectToPage("dota2", "/dota2/leagues")
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
							this.redirectToPage("overwatch", "/overwatch/leagues")
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
							this.redirectToPage("valorant", "/valorant/leagues")
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

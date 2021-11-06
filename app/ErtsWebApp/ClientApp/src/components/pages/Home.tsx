import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import { RouteComponentProps } from "react-router";

type IProps = RouteComponentProps;

class Home extends React.Component<IProps> {
	private redirectToPage(page: string) {
		this.props.history.push(page);
	}

	render() {
		return (
			<Container style={{ margin: "20vh" }} fluid>
				<Row className="align-items-center">
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("valorant")}
							src="/images/valorant-icon.png"
							width={200}
							height={200}
							alt="valorantLogo"
						/>
					</Col>
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("dota2")}
							src="/images/dota2-icon.png"
							width={325}
							height={325}
							alt="dota2Logo"
						/>
					</Col>
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("lol")}
							src="/images/lol-icon.png"
							width={400}
							height={400}
							alt="lolLogo"
						/>
					</Col>
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("csgo")}
							src="/images/csgo-icon.png"
							width={300}
							height={300}
							alt="csgoLogo"
						/>
					</Col>
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("overwatch")}
							src="/images/overwatch-icon.png"
							width={200}
							height={200}
							alt="r6Logo"
						/>
					</Col>
				</Row>
			</Container>
		);
	}
}
export default Home;

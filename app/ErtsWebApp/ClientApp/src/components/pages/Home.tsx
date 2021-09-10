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
			<Container style={{ paddingTop: "20vh" }}>
				<Row className="align-items-center">
					<Col md="auto">
						<img
							onClick={() => this.redirectToPage("r6")}
							src="/images/r6-icon.png"
							width={300}
							height={300}
							alt="r6Logo"
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
				</Row>
			</Container>
		);
	}
}
export default Home;

import React from "react";
import { Container, Row, Col } from "react-bootstrap";
class Home extends React.Component {
	render() {
		return (
			<Container style={{ paddingTop: "20vh" }}>
				<Row className="align-items-center">
					<Col md="auto">
						<a href="/r6">
							<img
								src="/images/r6-icon.png"
								width={300}
								height={300}
								alt="r6Logo"
							/>
						</a>
					</Col>
					<Col md="auto">
						<a href="/lol">
							<img
								src="/images/lol-icon.png"
								width={400}
								height={400}
								alt="lolLogo"
							/>
						</a>
					</Col>
					<Col md="auto">
						<a href="/csgo">
							<img
								src="/images/csgo-icon.png"
								width={300}
								height={300}
								alt="csgoLogo"
							/>
						</a>
					</Col>
				</Row>
			</Container>
		);
	}
}
export default Home;

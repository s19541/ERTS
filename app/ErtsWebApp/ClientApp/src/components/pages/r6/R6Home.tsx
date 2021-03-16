import React from "react";
import { Container, Row, Col } from "react-bootstrap";
class R6Home extends React.Component {
	render() {
		return (
			/*<div className="container">
				<a href="/r6">
					<img src="/images/r6-icon.png" width="300" height="300" alt="" />
				</a>
				<a href="/csgo">
					<img src="/images/lol-icon.png" width="400" height="400" alt="" />
				</a>
				<a href="/lol">
					<img src="/images/csgo-icon.png" width="300" height="300" alt="" />
				</a>
			</div>*/
			<Container style={{ paddingTop: "20vh" }}>
				<Row className="align-items-center">
					<Col md="auto">
						<img src="/images/lol-icon.png" width={400} height={400} alt="" />
					</Col>
					<Col md="auto">
						<img src="/images/csgo-icon.png" width={300} height={300} alt="" />
					</Col>
				</Row>
			</Container>
		);
	}
}
export default R6Home;

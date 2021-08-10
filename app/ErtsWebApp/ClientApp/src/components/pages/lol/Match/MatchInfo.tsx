import { Container, Row, Col } from "react-bootstrap";
import { MatchDto } from "../../../../services/GeneratedClient";

function MatchInfo(props: { match: MatchDto | null }) {
	var match = props.match;
	return (
		<Container>
			<Row className="align-items-center">
				<Col style={{ textAlign: "right" }}>
					<img
						src={match?.team1ImageUrl}
						className=""
						width={100}
						height={100}
					/>
				</Col>
				<Col style={{ textAlign: "left" }}>
					<div className="h4 text-white">{match?.team1Name}</div>
				</Col>
				<Col
					style={{
						width: "5vh",
						textAlign: "center",
					}}
				>
					<div className="h1 text-white">
						{match?.team1GamesWon}:{match?.team2GamesWon}
					</div>
				</Col>
				<Col style={{ textAlign: "right" }}>
					<div className="h4 text-white">{match?.team2Name}</div>
				</Col>
				<Col style={{ textAlign: "left" }}>
					<img
						src={match?.team2ImageUrl}
						className=""
						width={100}
						height={100}
					/>
				</Col>
			</Row>
			<Row>
				<Col style={{ textAlign: "center" }}>
					<div className="h4 text-white">
						{match?.startTime.format("HH:mm DD-MM-YYYY")}
					</div>
				</Col>
			</Row>
			<Row>
				<Col style={{ textAlign: "center" }}>
					<p>
						<a href={match?.streamUrl} className="h4 text-white">
							{match?.streamUrl}
						</a>
					</p>
				</Col>
			</Row>
		</Container>
	);
}

export default MatchInfo;

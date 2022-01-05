import { Container, Row, Col, Image } from "react-bootstrap";
import { MatchDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

interface IProps {
	match: MatchDto | null;
	gameType: string;
}

const MatchInfo: React.FunctionComponent<IProps> = (props) => {
	var match = props.match;
	var gameType = props.gameType;

	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}

	return (
		<Container className="text-white">
			<Row className="align-items-center">
				<Col style={{ textAlign: "right" }}>
					<Image
						src={match?.matchShortDto?.team1ImageUrl}
						className=""
						width={100}
						height={100}
						onClick={() => redirectToPage(`/${gameType}/team/${match?.team1Id}`)}
					/>
				</Col>
				<Col style={{ textAlign: "left" }}>
					<h4>{match?.team1Name}</h4>
				</Col>
				<Col
					style={{
						width: "5vh",
						textAlign: "center",
					}}
				>
					<h1>
						{match?.matchShortDto?.team1GamesWon}:{match?.matchShortDto?.team2GamesWon}
					</h1>
				</Col>
				<Col style={{ textAlign: "right" }}>
					<div className="h4 text-white">{match?.team2Name}</div>
				</Col>
				<Col style={{ textAlign: "left" }}>
					<Image
						src={match?.matchShortDto?.team2ImageUrl}
						className=""
						width={100}
						height={100}
						onClick={() => redirectToPage(`/${gameType}/team/${match?.team2Id}`)}
					/>
				</Col>
			</Row>
			<Row>
				<Col style={{ textAlign: "center" }}>
					<h4>
						{match?.matchShortDto?.startTime?.format("HH:mm DD-MM-YYYY")}
					</h4>
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

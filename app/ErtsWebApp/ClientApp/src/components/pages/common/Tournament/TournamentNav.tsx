import { Nav } from "react-bootstrap";
import { useHistory } from "react-router";

function TournamentNav(props: { activeKey: string, gameType: string }) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}
	const key = props.activeKey;
	const gameType = props.gameType;

	return (
		<Nav justify variant="tabs" activeKey={key} className="font-weight-bold">
			<Nav.Item>
				<Nav.Link eventKey="score-board" onClick={() => redirectToPage("./scoreboard")}>
					SCOREBOARD
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="matches" onClick={() => redirectToPage("./matches")}>
					MATCHES
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="player-stats" onClick={() => redirectToPage("./playerStats")} disabled={gameType != "lol"}>
					PLAYER STATS
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="team-stats" onClick={() => redirectToPage("./teamStats")} disabled={gameType != "lol"}>
					TEAM STATS
				</Nav.Link>
			</Nav.Item>
		</Nav>
	);
}

export default TournamentNav;

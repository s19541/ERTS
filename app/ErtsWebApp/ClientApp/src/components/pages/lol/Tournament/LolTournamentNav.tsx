import { Nav } from "react-bootstrap";

function LolTournamentNav(props: { activeKey: string }) {
	const key = props.activeKey;

	return (
		<Nav justify variant="tabs" activeKey={key} className="font-weight-bold">
			<Nav.Item>
				<Nav.Link eventKey="score-board" href="./scoreBoard">
					SCOREBOARD
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="matches" href="./matches">
					MATCHES
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="player-stats" href="./playerStats">
					PLAYER STATS
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="team-stats">TEAM STATS</Nav.Link>
			</Nav.Item>
		</Nav>
	);
}

export default LolTournamentNav;

import { Nav } from "react-bootstrap";
import { useHistory } from "react-router";

function LolTournamentNav(props: { activeKey: string }) {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}
	const key = props.activeKey;

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
				<Nav.Link eventKey="player-stats" onClick={() => redirectToPage("./playerStats")}>
					PLAYER STATS
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="team-stats" onClick={() => redirectToPage("./teamStats")}>TEAM STATS</Nav.Link>
			</Nav.Item>
		</Nav>
	);
}

export default LolTournamentNav;

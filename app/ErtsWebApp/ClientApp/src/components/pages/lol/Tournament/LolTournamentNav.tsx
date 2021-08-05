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
				<Nav.Link eventKey="series" href="./series">
					SERIES
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="link-2">PLAYER STATS</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="disabled" disabled>
					DISABLED
				</Nav.Link>
			</Nav.Item>
		</Nav>
	);
}

export default LolTournamentNav;

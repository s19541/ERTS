import { Nav } from "react-bootstrap";
import { useHistory } from "react-router";
import { useTranslation } from "react-i18next";

interface IProps {
	activeKey: string;
	gameType: string;
}

const TournamentNav: React.FunctionComponent<IProps> = (props) => {
	let history = useHistory();
	const redirectToPage = (page: string) => {
		history.push(page);
	}
	const key = props.activeKey;
	const gameType = props.gameType;
	const { t } = useTranslation();

	return (
		<Nav justify variant="tabs" activeKey={key} className="font-weight-bold">
			<Nav.Item>
				<Nav.Link eventKey="scoreboard" onClick={() => redirectToPage("./scoreboard")}>
					{t("tournament.nav.scoreboard").toUpperCase()}
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="matches" onClick={() => redirectToPage("./matches")}>
					{t("tournament.nav.matches").toUpperCase()}
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="player-stats" onClick={() => redirectToPage("./playerStats")} disabled={gameType != "lol"}>
					{t("tournament.nav.player-stats").toUpperCase()}
				</Nav.Link>
			</Nav.Item>
			<Nav.Item>
				<Nav.Link eventKey="team-stats" onClick={() => redirectToPage("./teamStats")} disabled={gameType != "lol"}>
					{t("tournament.nav.team-stats").toUpperCase()}
				</Nav.Link>
			</Nav.Item>
		</Nav>
	);
}

export default TournamentNav;

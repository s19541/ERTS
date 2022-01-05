import { Table } from "react-bootstrap";
import { LolGamePlayerShortStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerStatsTableRow from "./GamePlayerStatstableRow";
import { useTranslation } from "react-i18next";

interface IProps {
	playerStatsList: LolGamePlayerShortStatsDto[] | undefined;
}

const GamePlayerStatsTable: React.FunctionComponent<IProps> = (props) => {
	const playerStatsList = props.playerStatsList;
	const { t } = useTranslation();

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th
						style={{
							textAlign: "center",
						}}
					></th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						{t("match.nick")}
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						KDA
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						CS
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						{t("match.gold")}
					</th>
					<th
						style={{
							textAlign: "center",
						}}
					>
						{t("match.items")}
					</th>
				</tr>
			</thead>
			<tbody>
				{playerStatsList?.map((playerStats, i) => (
					<GamePlayerStatsTableRow playerStats={playerStats} />
				))}
			</tbody>
		</Table>
	);
}

export default GamePlayerStatsTable;

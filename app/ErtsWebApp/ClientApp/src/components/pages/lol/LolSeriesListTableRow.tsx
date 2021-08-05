import { SeriesShortDto } from "../../../services/GeneratedClient";

function LolSeriesTableRow(props: { series: SeriesShortDto }) {
	const series = props.series;
	const startTime = series.startTime.format("HH:mm DD-MM-YYYY");
	var result = series.blueTeamGamesWon + ":" + series.redTeamGamesWon;
	if (series.endTime == null) result = "vs";
	const winner =
		series.blueTeamGamesWon > series.redTeamGamesWon ? "Blue" : "Red";
	const mode =
		winner == "Blue"
			? "BO" + (series.blueTeamGamesWon * 2 - 1)
			: "BO" + (series.redTeamGamesWon * 2 - 1);

	return (
		<tr>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				{startTime}
			</td>
			<td
				style={{
					textAlign: "right",
					verticalAlign: "middle",
				}}
			>
				{series.blueTeamAcronym}
				<img
					src={series.blueTeamImageUrl}
					className=""
					width={50}
					height={50}
				/>
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{result}
			</td>
			<td
				style={{
					verticalAlign: "middle",
				}}
			>
				<img src={series.redTeamImageUrl} className="" width={50} height={50} />
				{series.redTeamAcronym}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{mode}
			</td>
		</tr>
	);
}
export default LolSeriesTableRow;

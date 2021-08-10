import { Col, Row } from "react-bootstrap";
import { LolGamePlayerShortStatsDto } from "../../../../services/GeneratedClient";

function GamePlayerStatsTableRow(props: {
	playerStats: LolGamePlayerShortStatsDto;
}) {
	const playerStats = props.playerStats;

	return (
		<tr>
			<td
				style={{
					verticalAlign: "middle",
					width: "17vh",
				}}
			>
				<Row>
					<Col md="auto" sm={8} style={{ textAlign: "right" }}>
						<img
							src={playerStats?.championImageUrl}
							className=""
							width={60}
							height={60}
						/>
					</Col>
					<Col md="auto" style={{ textAlign: "center" }}>
						<Row>
							<Col style={{ textAlign: "center" }}>
								<img
									src={playerStats?.spell1ImageUrl}
									className=""
									width={29}
									height={29}
								/>
							</Col>
						</Row>

						<Row>
							<Col
								md="auto"
								style={{ textAlign: "center", verticalAlign: "middle" }}
							>
								<img
									src={playerStats?.spell2ImageUrl}
									className=""
									width={29}
									height={29}
								/>
							</Col>
						</Row>
					</Col>
				</Row>
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{playerStats.playerNick}
			</td>
			<td
				style={{
					textAlign: "center",
					verticalAlign: "middle",
				}}
			>
				{playerStats.kills}/{playerStats.deaths}/{playerStats.assists}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.cs}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "center",
				}}
			>
				{playerStats.goldEarned}
			</td>
			<td
				style={{
					verticalAlign: "middle",
					textAlign: "left",
				}}
			>
				{playerStats.itemImages?.map((itemImage, i) => (
					<img src={itemImage} className="" width={35} height={35} />
				))}
			</td>
		</tr>
	);
}
export default GamePlayerStatsTableRow;

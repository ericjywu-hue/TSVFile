# TSV資料檔讀取 (TSV File Reader)

## 簡介

本程式為 Windows Form 應用程式，可讀取 TSV（Tab-Separated Values）格式的單字資料檔，並以表格方式顯示單字、音標、音檔路徑及解釋等欄位。

> 視窗程式設計二 上課範例  
> Copyright © 2026 by Eric Wu｜元智大學資訊工程學系  
> 版本：1.0.0.0

---

## 執行畫面

### 主畫面（啟動時）
<img width="495" height="486" alt="螢幕擷取畫面 2026-05-20 154235" src="https://github.com/user-attachments/assets/48a43f13-73fc-4fb3-b3fc-fff44ca974a0" />


程式啟動後，下方狀態列顯示「請開啟檔案」，提示使用者開啟 TSV 資料檔。

---

### File 選單（Alt+F）
<img width="494" height="493" alt="螢幕擷取畫面 2026-05-20 154308" src="https://github.com/user-attachments/assets/90f08b34-b7a0-4600-922f-04fed73978d0" />


| 功能 | 快捷鍵 |
|------|--------|
| Open（開啟檔案） | Ctrl+O |
| Exit（離開） | Ctrl+E |

---

### Help 選單（Alt+H）
<img width="494" height="487" alt="螢幕擷取畫面 2026-05-20 154320" src="https://github.com/user-attachments/assets/42e1cdd5-3174-48c9-a26a-e21d900c5097" />


| 功能 | 快捷鍵 |
|------|--------|
| About（關於） | Ctrl+A |

---

### 讀取資料後的畫面
<img width="493" height="487" alt="螢幕擷取畫面 2026-05-20 154347" src="https://github.com/user-attachments/assets/ddaf1f4b-9270-413e-87b4-7d1396fc8651" />


成功開啟 TSV 檔案後，資料會顯示於 ListView 中，包含以下四個欄位：

| 欄位 | 說明 |
|------|------|
| 單字 | 英文單字 |
| 音標 | 國際音標（IPA） |
| 音檔路徑 | 對應音檔的相對路徑（例：`Sound\A\abacus.mp3`） |
| 解釋 | 中文解釋 |

---

### 離開確認對話框
<img width="293" height="208" alt="螢幕擷取畫面 2026-05-20 154417" src="https://github.com/user-attachments/assets/f95642da-293b-433e-8607-c9e62ab78793" />


按下 Exit 或關閉視窗時，會彈出確認對話框，詢問是否確定要離開。選擇「是(Y)」則關閉程式，選擇「否(N)」則取消。

---

### 關於視窗（About）
<img width="547" height="367" alt="螢幕擷取畫面 2026-05-20 154437" src="https://github.com/user-attachments/assets/ea834898-8085-418b-93dd-fde30b0b347b" />


顯示程式名稱、版本、版權資訊及課程說明。

---

## 專案結構

```
TSVFile/
├── frmTSVFile.cs           # 主視窗邏輯
├── frmTSVFile.Designer.cs  # 主視窗 UI 設計
├── WordCollection.cs       # 單字集合類別（繼承 Collection<WordItem>）
└── WordItem.cs             # 單字資料類別
```

---

## 核心類別說明

### `WordItem`
代表一筆單字資料，由 TSV 單行字串解析而來。

| 屬性 | 型別 | 說明 |
|------|------|------|
| `Word` | `string` | 單字 |
| `Phonogram` | `string` | 音標 |
| `SoundPath` | `string` | 音檔路徑 |
| `Explain` | `string` | 解釋（支援多欄位合併，以換行分隔） |

建構子接受一行 TSV 字串，以 `\t` 分隔後依序指派欄位。第四欄（含）之後的內容會合併為解釋欄位。

### `WordCollection`
繼承 `Collection<WordItem>`，提供 `LoadFromStringArray(string[] lines)` 方法，批次將字串陣列轉換並載入為 `WordItem` 集合。

### `frmTSVFile`
主視窗，包含：
- 選單列（File / Help）
- ListView（顯示單字資料表格）
- 狀態列（顯示提示訊息）

---

## TSV 檔案格式

每行代表一筆單字資料，欄位以 **Tab（`\t`）** 分隔：

```
單字\t音標\t音檔路徑\t解釋
```

**範例：**
```
abacus	ˈæbəkəs	Sound\A\abacus.mp3	算盤
abandon	əˈbændən	Sound\A\abandon.mp3	放棄；遺棄
```

支援 `.txt` 及 `.tsv` 副檔名，檔案編碼須為 **UTF-8**。

---

## 使用方式

1. 啟動程式。
2. 按 **Alt+F** 開啟 File 選單，或直接按 **Ctrl+O**。
3. 在開啟檔案對話框中選擇 TSV 格式的單字資料檔。
4. 資料載入後，單字清單會顯示於主視窗的表格中。
5. 離開時按 **Ctrl+E** 或關閉視窗，確認後結束程式。

---

## 開發環境

- 語言：C#
- 框架：.NET Framework（Windows Forms）
- IDE：Visual Studio
